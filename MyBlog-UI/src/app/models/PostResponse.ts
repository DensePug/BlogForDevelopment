import { Post } from "./post";

export class PostResponse {
    constructor(pageCount: number, posts: Post[]) {
        this.posts = posts;
        this.pageCount = pageCount;
    }

    public pageCount: number;
    public posts: Post[];
}