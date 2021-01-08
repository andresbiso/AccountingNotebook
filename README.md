# General
- [Exercise](https://agileengine.gitlab.io/interview/test-tasks/fsNDJmGOAwqCpzZx/)
- Stack:
	- Front: Angular 11
	- Back: .NET 5

# Instructions

- After extracting the zip file you should have the following directory structure:
```
src/ -> source code of both the bakend and frontend applications
dist/ -> prod builds for both the backend and the frontend
readme.md -> this file
```
## How to run FrontEnd (AccountingNotebook)

- Install [node.js](https://nodejs.org/en/)

- Install [http-server](https://github.com/http-party/http-server) package globally (need to have node.js installed first):

```
npm install http-server -g
```

- Then inside the "dist" directory(in the terminal), just run:

```
http-server AccountingNotebook
```

- App should be up and running on http://127.0.0.1:8080/ by default.

## How to run BackEnd (AccountingNotebookAPI)

- Install [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0). I recommend installing the SDK but the runtime will also let you run the app.

- Inside the "dist" directory(in the terminal), enter the "AccoutingNotebookAPI" directory and run:
```
dotnet AccountingNotebookAPI.dll
```

- App should be up and running on https://localhost:5001/ by default.

## How to test the API

- If you enter https://localhost:5001/ you will have access to a completely configured swagger page from where you can test out the API.
- Once you have "POST"ed some transactions, go to http://127.0.0.1:8080/ and it will load them as a list. If you keep adding more transactions, just hit the "Refresh" button above the list to reload the list.
- By clicking the "+", at the end of each element of the list, it will display the whole transaction in detail.
