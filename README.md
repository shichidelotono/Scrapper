# Prodject description

To provide a manual scrapping searching result functiona and find out the location position of a targeted url/string based on search keyword.

# Implementation

The project is implemented in .Net Core. It contains 2 solutions: WebApi and Console App.

* Console App provides user to input search keyword and target keyword (e.g. url or string).
* WebApi provides an endpoint to console app making a web service call.

# Getting Started

You can run the console app and the webapi in Visual Studio 2017, console, or docker container(scripts provided)

## Prerequisites

Install the following

* .Net Core 2.1 or Docker

# Running the applications

Locate default.conf file in Scrapper.Runner solution folder. This is the configuration file to config webapi endpoint for local machine and docker 

## Local

* Open Scrapper.Api solution in VS and run
* Set webapi endpoing in default.conf
* Open Scrapper.Runner solution in VS and run

or 

* Go to api path
* `dotnet restore`
* `dotnet build`
* `dotnet run`

* Go to runner path
* Change base url config
* `dotnet restore`
* `dotnet build`
* `dotnet run`


## Running it with Docker

If you have docker installed you can

* First, create network: `docker network create scrapper-network`

* Go to scrapper api path.
* Build scrapper api: `docker build -t scrapper-api .`
* Run scrapper api: `docker run --name scrapper-api-container --net scrapper-network scrapper-api`

* Set webapi endpoing in default.conf
* Go to scrapper runner path
* Build scrapper runner: `docker build -t scrapper-runner .`
* Run scrapper runner: `docker run -it --network scrapper-network scrapper-runner`

## Use docker to run api only 

* Go to api path
* `docker run -p 5000:5000 scrapper-api`
* Set webapi endpoing in default.conf
* Run Scrapper.Runner in VS or from command line

### Useful Docker Commands

* List all running containers: `docker ps`
* List all containers: `docker ps -a`
* Start/Stop container `docker start/stop CONTAINER_ID`
* `You can write first 2 or 3 characters of container id instead of writing whole ID`
* List images: `docker images`
* Remove containers: `docker rm CONTAINER_ID`
* Remove images: `docker rmi IMAGE_ID`
* By using `docker build` command, you create an image using your Dockerfile
* Using an image, you can create a container.
