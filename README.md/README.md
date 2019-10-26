# Todo List API
## Summary
A todo list application programming interface allowing the creation of tasks that access the features or data of a to list.

## Routes and Responses
(assuming you are running locally on port 8080)
### todo object
* `objectId` : the mongo object identifer 
* `task` : the body of the todo
* `date` : is a `DateTime` of when the todo should be completed
* `status` : tells if the todo is completed
* `todoId` : a unique identifier for each todo for updating and deleting purposes

### Create a todos
* Method: POST
* Route: `http://localhost:8080/todos`
* Response: a newly created todos
```[ {
	"task": "This is awesome",
  "date": "2016-05-18T16:00:00Z",
  "status": true
},
{
  "objectId": "5db3d4c06dc0c90001b9bc09",
  "task": "This is awesome",
  "date": "2016-05-18T16:00:00Z",
  "status": true,
  "todoId": "656c1746"
}
```
### Get all todos
* Method: GET
* Route: `http://localhost:8080/todos`
* Response: a list of todos
```
[ 
  {"objectId": "5db3b7df499cf40001fe23e0",
  "task": "go to the store",
  "date": "2016-05-18T16:00:00Z",
  "status": true,
  "todoId": "bbb9931c"
  },
  {
  "objectId": "5db3d4c06dc0c90001b9bc09",
  "task": "This is awesome",
  "date": "2016-05-18T16:00:00Z",
  "status": true,
  "todoId": "656c1746"
  },
  {
  "objectId": "7dx3b7df499cf6954fe2a02",
  "task": "walk the dog",
  "date": "2016-05-18T16:00:00Z",
  "status": false,
  "todoId": "c879925a"
  }
]
```
### Edit a todos
* Method: PUT
* Route: `http://localhost:8080/todos/656c1746`
* Response: a edited todos
```
[ 
  {
	"task": "I changed it"
},
  {
  "objectId": "5db3d4c06dc0c90001b9bc09",
  "task": "I changed it",
  "date": "2016-05-18T16:00:00Z",
  "status": true,
  "todoId": "656c1746"
}
]
```
### Delete a todos
* Method: DEL
* Route: `http://localhost:8080/todos/656c1746`
* Response: a deleted todos
```[ 
{
  
},
{
  
}
```




## Running locally with docker
* to build from working directory:
`docker build -t todolistapi .`
* to run: 
`docker run -d -p 8080:80 --name myapp todolistapi`
* to view running container: 
`docker container ls`
* to stop: 
`docker stop <containerId>`
* to restart: 
`docker start <containerId>`
* show images, not running containers: `docker ps -l`
