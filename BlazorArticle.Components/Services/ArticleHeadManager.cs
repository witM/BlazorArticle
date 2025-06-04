
using Microsoft.AspNetCore.Components;

namespace BlazorArticle.Components.Services
{

    /// <summary>
    /// Manage the style content in the head tag. It is used by "ArticleStyleContent" and "ArticleStyleOutlet" components.
    /// </summary>
    public class ArticleHeadManager
    {
        /// <summary>
        /// This is the of the <style> element that "ArticleStyleOutlet" component renders.
        /// </summary>
        public string ArticleStyleId { get; private set; }

        //public RenderFragment? ArticleFragment { get; private set; }

        /// <summary>
        /// The style that is rendered by "ArticleStyleOutlet" component.
        /// </summary>
        public string? ArticleStyle { get; private set; }

        public event Func<Task>? OnFragmentChanged;


        public ArticleHeadManager() 
        {
            ArticleStyleId = "art";
        }

        public ArticleHeadManager(string styleId)
        {
            ArticleStyleId = styleId;
        }
       

        /* MANAGE THE ARTICLE STYLE */

        public async Task SetArticleFragment(RenderFragment articleFragment)
        {
            //ArticleFragment = articleFragment;
            await (OnFragmentChanged?.Invoke() ?? Task.CompletedTask);
        }

        public async Task SetArticleStyle(string style)
        {
            ArticleStyle = style;
            await (OnFragmentChanged?.Invoke() ?? Task.CompletedTask);

        }

        public void RemoveStylesAll()
        {
            //ArticleFragment = null;
            ArticleStyle = null;
            OnFragmentChanged?.Invoke();
        }


    }
}
