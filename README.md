# BlazorArticle

Library in .NET with blazor components to support rendering article from database with interactive server side component within the article. In summary, it is a library that supports the creation and rendering of pages with articles, such as blogs or educational materials.

The library will be good for bloggers and other educational content.

## Installation and documentation

The first version of library is under development...when it will be ready it will be published just as the "BlazorArticle" and "BlazorArticle.Components" packages.

In this file you will see base setup and example of usage of the libs.

There's a plan to make more advanced documentation on github page under blazor webassembly site using the BlazorArticle library itself.

## Projects information

The library is made from the **BlazorArticle** and **BlazorArticle.Components** projects. These will be used to build and publish nuget packages of the libraries.

**BlazorArticleWeb** is a Blazor Web App that uses server-side rendering on all pages to demonstrate the usage of libraries and test them.

**BlazorArticleWebClient** is a Blazor WebAssembly application for testing libraries on the client side and for the possibility of writing articles. You can use this app to write your own articles with a custom style and see how they look. Article rendering and its style are independent of your layout in a custom Blazor application.


## Additional stuff

Reported blazor issue: [DynamicComponent renders outside of surrounding HTML tags in InteractiveServer rendering](https://github.com/dotnet/aspnetcore/issues/61760)