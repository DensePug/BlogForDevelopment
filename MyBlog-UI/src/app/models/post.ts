export class Post {
    constructor(id: number, imageUrl: string, title: string, previewContent: string, dateCreated: Date, content: string, likeCount: number, tags: string[]) {
        this.id = id;
        this.title = title;
        this.imageUrl = imageUrl;
        this.previewContent = previewContent;
        this.content = content;
        this.dateCreated = dateCreated;
        this.tags = tags;
        this.likeCount = likeCount;
    }

    public likeCount: number;
    public imageUrl: string
    public id: number;
    public title: string;
    public tags: string[];
    public previewContent: string;
    public content: string;
    public dateCreated: Date;
}