export interface Token {
  authToken: string;
  userId: string;
  issuedAt: Date;
  expireAt: Date;

  
}


// constructor(
//   authToken: string,
//   userId: string,
//   issuedAt: Date,
//   expireAt: Date
// ) {
//   this.authToken = authToken;
//   this.userId = userId;
//   this.issuedAt = issuedAt;
//   this.expireAt = expireAt;
// }