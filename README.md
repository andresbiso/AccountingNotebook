<p align="center">
  <a href="" rel="noopener">
 <img width=400px height=200px src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTy0fsUAcKNJtiOgb3go_PGc6H_Pxv18u9v3A&usqp=CAU" alt="Project logo"></a>
</p>

<h3 align="center">Angular 11 and .NET 5 exercise</h3>

<div align="center">

  [![License](https://img.shields.io/github/license/andresbiso/AccountingNotebook)](/LICENSE)

</div>


## 📝 Table of Contents
- [About](#about)
- [Built Using](#built_using)
- [Getting Started](#getting_started)
- [Authors](#authors)

## 🧐 About <a name = "about"></a>
- [Exercise](https://github.com/andresbiso/AccountingNotebook/blob/main/exercise.md)

## 🏁 Getting Started <a name = "getting_started"></a>
### First Step
- After extracting the zip file you should have the following directory structure:
```
src/ -> source code of both the bakend and frontend applications
dist/ -> prod builds for both the backend and the frontend
readme.md -> this file
```
### How to run FrontEnd (AccountingNotebook)

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

### How to run BackEnd (AccountingNotebookAPI)

- Install [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0). I recommend installing the SDK but the runtime will also let you run the app.

- Inside the "dist" directory(in the terminal), enter the "AccoutingNotebookAPI" directory and run:
```
dotnet AccountingNotebookAPI.dll
```

- App should be up and running on https://localhost:5001/ by default.

### How to test the API

- If you enter https://localhost:5001/ you will have access to a completely configured swagger page from where you can test out the API.
- Once you have "POST"ed some transactions, go to http://127.0.0.1:8080/ and it will load them as a list. If you keep adding more transactions, just hit the "Refresh" button above the list to reload the list.
- By clicking the "+", at the end of each element of the list, it will display the whole transaction in detail.

## ⛏️ Built Using <a name = "built_using"></a>
- [**Angular 11**](https://angular.io/guide/setup-local)
- [**.NET 5**](https://dotnet.microsoft.com/download/dotnet/5.0)

## ✍️ Authors <a name = "authors"></a>
- [@andresbiso](https://github.com/andresbiso)

