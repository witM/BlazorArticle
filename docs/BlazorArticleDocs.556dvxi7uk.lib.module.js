

/*BLAZOR INITIALIZERS CALLED AUTOMATICALLY BY BLAZOR*/
/*https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/startup?view=aspnetcore-9.0#javascript-initializers */

export function beforeWebStart(options) {
    console.log("before web start...");
}

export function afterWebStarted(blazor) {
    console.log("after web started...");
    JS_ParsePage();
    //"enhancedload" event is used when user change page after first initial website rendered (statically or interactively) if enhanced navigation is possible otherwise total site refresh is done and use
    //WARNING:For interactive rendered page (components) code calling in OnPageChanged may not take effect because of rerendering after calling this function
    blazor.addEventListener("enhancedload", OnPageChanged);
}

function OnPageChanged() {
    console.log("enhanced navigation worked !!! ");
    JS_ParsePage();

}