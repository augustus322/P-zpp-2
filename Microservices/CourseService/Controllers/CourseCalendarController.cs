using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CourseService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly List<Course> _courses;
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly string courseServiceBaseAddress = "http://localhost:5173/szkolenia";
        private readonly string calendarServiceBaseAddress = "http://localhost:5173/kalendarz";

        public CourseController(ILogger<CourseController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _courses = new List<Course>();
            _httpClientFactory = httpClientFactory;
        }

        // Get all courses
        [HttpGet("courses")]
        public IEnumerable<Course> GetCourses()
        {
            return _courses;
        }

        // Create a new course using CourseBuilder
        [HttpPost("courses")]
        public IActionResult CreateCourse([FromBody] CourseBuilderRequest request)
        {
            var builder = new CourseBuilder();
            builder.SetTitle(request.Title)
                   .SetDescription(request.Description)
                   .SetStartDate(request.StartDate)
                   .SetEndDate(request.EndDate);

            if (request.TrainerId != null)
            {
                builder.SetTrainer(request.TrainerId.Value);
            }

            var course = builder.Build();
            _courses.Add(course);
            return Ok();
        }

        // Schedule a course by making an HTTP request to another microservice
        [HttpPost("courses/{id}/schedule")]
        public async Task<IActionResult> ScheduleCourse(int id, [FromBody] DateTime dateTime)
        {
            var course = _courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound(); // Return 404 if the course is not found

            var client = _httpClientFactory.CreateClient();
            var meetingRequest = new
            {
                Title = course.Title,
                DateTime = dateTime
            };
            var content = new StringContent(JsonSerializer.Serialize(meetingRequest), System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{calendarServiceBaseAddress}/ScheduleCourse", content);

            if (response.IsSuccessStatusCode)
            {
                course.Schedule(dateTime); // Mark the course as scheduled
                return Ok();
            }

            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync()); // Return the response status code and content
        }

        // Get the Google Calendar events
        [HttpGet("calendar/events")]
        public async Task<IActionResult> GetCalendarEvents()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{calendarServiceBaseAddress}/api/calendar/events");

            if (response.IsSuccessStatusCode)
            {
                var events = await response.Content.ReadAsStringAsync();
                return Ok(events);
            }

            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        // Add an event to Google Calendar
        [HttpPost("calendar/events")]
        public async Task<IActionResult> AddCalendarEvent([FromBody] CalendarEventRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{calendarServiceBaseAddress}/api/calendar/events", content);

            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }

            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }
}


    // Builder pattern for creating Course objects
    public class CourseBuilder
    {
        private Course _course;

        public CourseBuilder()
        {
            _course = new Course(); // Initialize a new Course object
        }

        public CourseBuilder SetTitle(string title)
        {
            _course.Title = title;
            return this;
        }

        public CourseBuilder SetDescription(string description)
        {
            _course.Description = description;
            return this;
        }

        public CourseBuilder SetStartDate(DateTime startDate)
        {
            _course.StartDate = startDate;
            return this;
        }

        public CourseBuilder SetEndDate(DateTime endDate)
        {
            _course.EndDate = endDate;
            return this;
        }

        public CourseBuilder SetTrainer(int trainerId)
        {
            _course.TrainerId = trainerId;
            return this;
        }

        public Course Build()
        {
            return _course; // Return the constructed Course object
        }
    }

    // Request model for creating a new course
    public class CourseBuilderRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? TrainerId { get; set; }
    }

    // Course model
    public class Course
    {
        public int Id { get; set; } // Assuming we have an Id to identify courses
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? TrainerId { get; set; }
        public DateTime? ScheduledDate { get; private set; }

        // Method to schedule the course
        public void Schedule(DateTime dateTime)
        {
            ScheduledDate = dateTime;
        }
    }

    // Request model for adding a calendar event
    public class CalendarEventRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}


