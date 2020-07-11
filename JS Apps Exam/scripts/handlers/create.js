import { requester } from "../services/app-service.js";
import { applyCommon } from "./common.js";
import { createFormEntity } from "../form-helpers.js";

export async function createHandler() {
    await applyCommon.call(this);

    await this.partial("../../templates/create/createPage.hbs");

    const formRef = document.querySelector("form"); 
    const form = createFormEntity(formRef,  ["title", "category", "content"]);

    formRef.addEventListener("submit", async (event) => {
        event.preventDefault();

        const { title, category, content } = form.getValue();

        const categoryLowerCase = category.toLowerCase();

        if (!title) {
            throw new Error("Article must have a title")
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

        await requester.articles.createEntity({ 
            title,
            category,
            content,
            creator: localStorage.getItem("email")
        });

        form.clear();

        this.redirect(['#/home']);
    })
};