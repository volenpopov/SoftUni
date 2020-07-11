import { applyCommon } from "./common.js";
import { requester } from "../services/app-service.js";

export async function detailsHandler() {
    await applyCommon.call(this);

    const articleId = this.params.id;
    const userEmail = localStorage.getItem("email");
    
    const { title, category, content, creator } = await requester.articles.getById(articleId);

    this.articleId = articleId;
    this.title = title;
    this.category = category;
    this.content = content;
    this.isCreator = creator === userEmail; 
    
    await this.partial("../../templates/details/detailsPage.hbs");
}