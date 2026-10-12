# RentMyRide — .NET backend conversion

This conversion keeps the existing React + Vite frontend and replaces the Spring Boot backend with an ASP.NET Core 8 Web API foundation.

## Stack
- ASP.NET Core 8 Web API
- Entity Framework Core 8 + Pomelo MySQL provider
- MySQL
- Swagger/OpenAPI
- Existing React/Vite frontend retained without redesign

## Run the API
1. Install the .NET 8 SDK and MySQL.
2. Create a MySQL database named `rentmyride`.
3. Edit `backend/appsettings.json` and set your database password, or set `DB_CONNECTION`.
4. From `backend/` run:
   ```bash
   dotnet restore
   dotnet run
   ```
5. Open the Swagger URL shown in the console (in Development, normally `/swagger`).
6. Start the frontend from `frontend/` using `npm install` then `npm run dev`.

## Current API routes
- `GET /api/health`
- `GET /api/cars`
- `GET /api/cars/available`
- `GET /api/cars/search?keyword=suv`
- `GET /api/cars/{id}`
- `POST /api/cars`
- `PUT /api/cars/{id}`
- `PATCH /api/cars/{id}/status?status=AVAILABLE`
- `DELETE /api/cars/{id}` (retires the car)

## Important conversion notes
- Java entity equivalents have been started for Admin, Car, Customer, Driver, Reservation, Rental, Payment, PromoCode, Feedback, Notification, and OTP verification.
- The Car API is implemented as working CRUD against MySQL. The remaining Java controllers/services, full JWT role-based authentication, OTP/email/Twilio, Razorpay payment verification, PDF receipts, reservation pricing/availability rules, and complete DTO/validation behavior still require porting and testing. This is a conversion foundation, not a verified one-to-one migration of every workflow.
- The frontend is preserved as-is; verify its Axios base URL and endpoint response expectations before using it with this API.
- Do not commit database passwords, JWT secrets, or payment credentials.
