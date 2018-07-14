### Running it with Docker

* First, create network: `docker network create scrapper-network`

* Go to scrapper api path.
* Build scrapper api: `docker build -t scrapper-api .`
* Run scrapper api: `docker run --name scrapper-api-container --net scrapper-network scrapper-api`

* Go to scrapper runner path
* Build scrapper runner: `docker build -t scrapper-runner .`
* Run scrapper runner: `docker run -it --network scrapper-network scrapper-runner`


### Useful Docker Commands

* List all running containers: `docker ps`
* List all containers: `docker ps -a`
* Start/Stop container `docker start/stop CONTAINER_ID`
* `You can write first 2 or 3 characters of container id instead of writing whole ID`
* List images: `docker images`
* Remove containers: `docker rm CONTAINER_ID`
* Remove images: `docker rmi IMAGE_ID`
* By using `docker build` command, you create an image using your Dockerfile.
* Using an image, you can create a container.


### Use it without Docker

* Go to api path
* `dotnet restore`
* `dotnet build`
* `dotnet run`

* Go to runner path
* Change base url config
* `dotnet restore`
* `dotnet build`
* `dotnet run`