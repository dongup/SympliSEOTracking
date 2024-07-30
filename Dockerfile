# Use the official .NET image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /app

# Clone the GitHub repository
# Replace the following URL with your repository URL
RUN git clone https://github.com/dongup/SympliSEOTracking.git .

# Restore the NuGet packages
RUN dotnet restore

# Build the application
RUN dotnet publish -c Release -o /publish

# Use the official ASP.NET image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory in the container
WORKDIR /app

# Copy the build output from the build stage
COPY --from=build /publish .

# Expose the port that the app runs on
EXPOSE 8080

# Define the entry point for the container
ENTRYPOINT ["dotnet", "SympliSEOTracking.Web.dll"]