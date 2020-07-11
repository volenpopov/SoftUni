import { applyCommon } from "./common.js";
import { requester } from "../services/app-service.js";

export async function homeViewHandler() {
    await applyCommon.call(this);

    if (!this.loggedIn) {
        this.redirect(['#/login']);
    } else {
        const articles = await requester.articles.getAll();

        const jsArticles = [];
        const csharpArticles = [];
        const javaArticles = [];
        const pythonArticles = [];

        if (articles) {
            Object.entries(articles)
            .sort(([, a], [, b]) => b.title.localeCompare(a.title))
            .forEach(([id, article]) => {            
                const category = article.category.toLowerCase();
                const parsedArticle = { articleId: id, ...article };

                if (category === "js" || category === "javascript") {
                    jsArticles.push(parsedArticle);
                } else if (category === "csharp" || category === "c#") {
                    csharpArticles.push(parsedArticle);
                } else if (category === "java") {
                    javaArticles.push(parsedArticle);
                } else if (category === "python" || category === "pyton") {
                    pythonArticles.push(parsedArticle);
                }
            });
        }
            
        this.jsArticles = jsArticles;
        this.csharpArticles = csharpArticles;
        this.javaArticles = javaArticles;
        this.pythonArticles = pythonArticles;
        
        await this.partial("../templates/home/home.hbs");
    } 
};