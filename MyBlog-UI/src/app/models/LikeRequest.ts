import { ApiRequest } from "./ApiRequest";

export class LikeRequest extends ApiRequest {
    constructor(postId: number, dateUserLoggedInLiked: number) {
        super();
        this.postId = postId;
        this.dateUserLoggedInLiked = dateUserLoggedInLiked;
    }

    postId: number;
    dateUserLoggedInLiked: number;
}