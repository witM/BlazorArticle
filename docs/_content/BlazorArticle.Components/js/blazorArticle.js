
function test() {
    alert("hello from BlazorArticle library");
}


function BlazorArticle_ScrollToTop() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
}
var g_isMobileSidebarActive = false;
function BlazorArticle_ToggleArticleNavigation() {
    //alert('hh');
    /* Toggle between showing and hiding the navigation menu links when the user clicks on the hamburger menu / bar icon */
    //get the toggler button
    var btn_toggler_toc = document.getElementById("m-sidebar-toggler");
    //get the sidebar container
    var sidebar = document.getElementById("m-sidebar");
    //
    g_isMobileSidebarActive = !g_isMobileSidebarActive;
    if (g_isMobileSidebarActive) {
        btn_toggler_toc.classList.add("active");
        //
        sidebar.classList.add("active");
        sidebar.classList.remove("hidden");

    }
    else {
        btn_toggler_toc.classList.remove("active");
        //
        sidebar.classList.add("hidden");
        sidebar.classList.remove("active");
    }
}

function JS_BlazorArticle_RenderArticleStyle(data) {
    //var x = 10;
    //We may check if <style> with given id exists and if not then create one, but we want render style exactly where "outled" compoents is so if ther is no element then skip style rendering
    ///////////////////////////////////////////////////////////////////
    var styleElement = document.getElementById(data.styleId)
    if (!styleElement) {
        //styleElement = document.createElement("style");
        //styleElement.id = data.styleId;
        //styleElement.type = "text/css";
        //styleElement.textContent = data.style;
        //document.head.appendChild(styleElement);
    }
    else {
        styleElement.textContent = data.style;
    }
}