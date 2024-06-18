import jwt from "jsonwebtoken";

const secretKey: jwt.Secret =
  "SecurityKeySecurityKeySecurityKeySecurityKeySecurityKey"; // secret key goes here
// TokenPayload

// Buffer.from(
//   "SecurityKeySecurityKeySecurityKeySecurityKeySecurityKey",
//   "base64")

const verifyToken = (token: string): TokenPayload | undefined => {
  // console.log("secret key: ", secretKey);

  try {
    var decodedPayload = jwt.verify(token, secretKey, {
      algorithms: ["HS256"],
    });
    // console.log("decoded payload", decodedPayload);

    var stringPayload = JSON.stringify(decodedPayload);

    var payload: TokenPayload = JSON.parse(stringPayload);

    // console.log("token payload object", payload);

    return payload;
  } catch (error) {
    console.error("token verification error:", error);
    return;
  }
};

const jwtVerificator = {
  verify: verifyToken,
};

type TokenPayload = {
  sub: number;
  email: string;
  Role: string;
  jti: string;
  exp: number;
  iss: string;
  aud: string;
};

export default jwtVerificator;
