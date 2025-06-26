<!-- https://github.com/witM/BlazorArticle -->
<!-- github pages: https://witm.github.io/BlazorArticle/ -->

# BlazorArticle

The Library in .NET with blazor components to support rendering article from database (or other sources like files for example) with interactive server side components within the article. In summary, it is a library that supports the creation and rendering of pages with articles, such as blogs, educational or documentation materials.

The library is designed to work with both Blazor Web App and Blazor WebAssembly Standalone applications.

## Installation and documentation

The documentation is hosted on GitHub pages [here](https://witm.github.io/BlazorArticle/). The website is built as a Blazor WebAssembly Standalone application and uses the library itself, so you can check how it works. The articles of documentation are rendering from plain html files.

This repository serves as a testing and development environment for the library. Do not treat it as a usage template for the library.
To test and build your own projects, download the dedicated Blazor Web App and Blazor WebAssembly Standalone templates from the official template repository [here](https://github.com/witM/BlazorArticleTemplates).

## Projects information

The library is made from the **BlazorArticle** and **BlazorArticle.Components** projects. These will be used to build and publish nuget packages of the libraries.

**BlazorArticleWeb** is a Blazor Web App that uses server-side rendering on all pages to demonstrate the usage of libraries and test them.

**BlazorArticleWebClient** is a Blazor WebAssembly application for testing libraries on the client side and for the possibility of writing articles. You can use this app to write your own articles with a custom style and see how they look. Article rendering and its style are independent of your layout in a custom Blazor application.


## Additional stuff

### Issues

Reported blazor issue: [DynamicComponent renders outside of surrounding HTML tags in InteractiveServer rendering](https://github.com/dotnet/aspnetcore/issues/61760)

### Externals

Regardless of the .NET components and the [Blazor framework](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor), the website projects, in addition to the [Bootstrap](https://getbootstrap.com) library, make use of the following libraries:
- [FontAwesome](https://fontawesome.com)
- [Katex](https://katex.org) Latex formula rendering as maths
- [TocBot](https://tscanlin.github.io/tocbot) Rendering Table of Content


### Learning

I plan to create a few videos, for example showing how to use the library to build a blog using Blazor Web App.
We'll see how the library evolves and whether it gains popularity.

You can view the development log (dev log) [here](https://www.youtube.com/watch?v=mfRf5yP0JRY&list=PLbctGVdzNn9TE0LZWewGu8Q8ykIZJ2v-B).