# Sympli SEO Tracking

Sympli SEO Tracking is a tool that helps users find the ranking of URLs in search engine search results. It leverages search engine APIs and custom algorithms to track and analyze the position of specified URLs for given keywords.

## Features

- **Keyword Tracking:** Monitor the position of URLs for specified keywords.
- **Search Engine Integration:** Supports multiple search engines for comprehensive tracking.

## Getting Started

To get started with Sympli SEO Tracking, follow the steps below.

### Prerequisites

- Docker installed on your machine. You can download and install Docker from [Docker's official website](https://www.docker.com/get-started).

### Running the Project with Docker

1. **Clone the Repository**

   Clone the project repository from GitHub:

   ```sh
   git clone https://github.com/dongup/SympliSEOTracking.git
   cd SympliSEOTracking
2. **Build the Docker Image**

    Navigate to the directory containing the Dockerfile and build the Docker image:

    ```sh
    docker build -t sympli-seo-tracking .
    Run the Docker Container

3. **After building the image, you can run the container:**

    ```sh
    docker run -p 8080:8080 sympli-seo-tracking
    This command will start the application and make it accessible at http://localhost:8080.

4. **Configuration**
The project can be configured using environment variables or a configuration file. You can specify the search engine API keys, default keywords, and other settings in the configuration file or environment variables.

5. **Accessing the Application**
Once the Docker container is running, you can access the URL Ranking Finder application through your web browser at:

    ```sh
    http://localhost:8080