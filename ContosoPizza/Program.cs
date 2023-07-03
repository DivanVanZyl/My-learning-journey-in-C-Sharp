/*
 * 1. Add model(s).
 * 2. Add DbContext.
 * 3. Create initial migration with "dotnet EF migrations add InitalCreate".
 * 4. Look at your generated migration. Check if the tables will be created in the way you want it to be created.
 * 5. Run "dotnet EF database update". If you recieve the error: "A connection was successfully established with the server, but then an error occurred during the login process", you might need to add "trusted_connection=true;TrustServerCertificate=true" to your connection string, 
 * 6. Now check the database that was created.
 */
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
