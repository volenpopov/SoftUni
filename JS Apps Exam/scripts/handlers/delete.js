import { applyCommon } from "./common.js";
import { requester } from "../services/app-service.js";

export async function deleteHandler() {
    await applyCommon.call(this);

    const articleId = this.params.id;

    await requester.articles.deleteEntity(articleId);

    this.redirect(['#/home']);
}
