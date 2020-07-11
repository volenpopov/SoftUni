import { applyCommon } from "./common.js";
import { requester } from "../services/app-service.js";
import { createFormEntity } from "../form-helpers.js";

export async function editHandler() {
    await applyCommon.call(this);

    const articleId = this.params.id;

    const article = await requester.articles.getById(articleId);

    this.title = article.title;
    this.category = article.category;
    this.content = article.content;

    await this.partial("../../templates/edit/editPage.hbs");

    const formRef = document.querySelector("form"); 
    const form = createFormEntity(formRef,  ["title", "category", "content"]);
    
    formRef.addEventListener("submit", async (event) => {
        event.preventDefault();

        const { title, category, content } = form.getValue();

        const categoryLowerCase = category.toLowerCase();

        if (!title) {
            throw new Error("The article must have a title");
        }

        if (!category) {
            throw new Error("The artcile must have a category");
        }

        if (categoryLowerCase !== "js" && categoryLowerCase !== "javascript"
            && categoryLowerCase !== "csharp" && categoryLowerCase !== "c#"
            && categoryLowerCase !== "java"
            && categoryLowerCase !== "python" && categoryLowerCase !== "pyton") {
                throw new Error("Invalid category");
        }

        await requester.articles.patchEntity({ 
            title, 
            category, 
            content
        }, articleId);

        form.clear();

        this.redirect(['#/home']);
    })
}