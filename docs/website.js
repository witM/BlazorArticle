
//Use for manually js configuration or testing
document.addEventListener("DOMContentLoaded", (e) => {

});

function RenderMath(element) {

    //render math in the given html element - this function is a part of the katex and katex-autorender library, see more:
    //https://katex.org/
    renderMathInElement(element,
        {
            output: "html",
            delimiters: [
                // {left: "$$", right: "$$", display: true},
                { left: "\\[", right: "\\]", display: true },
                // {left: "$", right: "$", display: false},
                // {left: "\\(", right: "\\)", display: false}
                { left: "\\$", right: "\\$", display: false }
            ],
            ignoredClasses: ["-not-render-math"]
        }
    );
}

/*Called after blazor started and every time page has changed*/
function JS_ParsePage() {
    RenderMath(document.body);
    InitializeCopyButtonsForCode();
}

function JS_RenderMathInElement(element) {
    RenderMath(element);
}

/**
 * Called after article is rendered to render table of content - it uses TOCBOT library: https://tscanlin.github.io/tocbot/
 * @param {any} url have to be absolute path to the article
 * @param {string} tocSelector is css selector where to render toc
 * @param {string} articleSelector is css selector from which the content of toc is rendered
 */
function JS_RenderTOC(url, tocSelector, articleSelector) {

    tocbot.init({
        // Where to render the table of contents.
        tocSelector: tocSelector,
        // Where to grab the headings to build the table of contents.
        contentSelector: articleSelector,
        // Which headings to grab inside of the contentSelector element.
        headingSelector: 'h2, h3, h4',
        // For headings inside relative or absolute positioned containers within content.
        hasInnerContainers: false,
        //how menu heading will be collapsed
        collapseDepth: 3,
        //
        basePath: url,
        // Only takes affect when `tocSelector` is scrolling,
        // keep the toc scroll position in sync with the content.
        disableTocScrollSync: true,   //true - prevent toc contect scrolling during scrolling the page content (site)
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////
        orderedList: false,
        includeHtml: true // if you want katex rendered in toc
    });
}


function ParseLanguageCode() {
    Prism.highlightAll();
}

//var g_isMobileTocActive = false;
function ToggleArticleNavigation() {

   
}

function InitializeCopyButtonsForCode() {
    const buttons = document.querySelectorAll('.copy-button');
    buttons.forEach(button => {
        // in if condition: prevent double event listener registration
        if (!button.dataset.copyBound) {
            button.addEventListener('click', () => CopyToClipboardFromCode(button));
            button.dataset.copyBound = 'true'; 
        }
    });
}


function CopyToClipboardFromCode(button) {
    // Find <code> in neighber <pre>
    const code = button.closest('.code-block')?.querySelector('pre > code');
    if (!code) return;

    // Copy content in the <code>
    const text = code.innerText;

    navigator.clipboard.writeText(text).then(() => {
        // change button style temporary
        const original = button.textContent;
        button.textContent = 'Copied!';
        button.classList.add('copied');   // class has to be defined in article style !!
        setTimeout(() => {
            button.textContent = original;
            button.classList.remove('copied'); 
        }, 1500);
    }).catch(err => {
        console.error('Copy failed', err);
    });
}
