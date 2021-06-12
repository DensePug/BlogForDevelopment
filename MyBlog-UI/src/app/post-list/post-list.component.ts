import { Component, OnInit } from '@angular/core';
import { LikeRequest } from '../models/LikeRequest';
import { Post } from '../models/post';
import { TransportService } from '../transport.service';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class PostListComponent implements OnInit {

  constructor(private transport: TransportService) { }

  posts: Post[] = [];
  desc: boolean | null = null;

  ngOnInit(): void {
    this.transport.get('api/Posts').subscribe((response) => {
      const posts = <Post[]>response;
      this.posts = posts;
    })
  }

  like(post: Post) {
    this.transport.patch('api/Posts/like', new LikeRequest(post.id, parseInt(<string>localStorage.getItem('dateLoggedIn')))).subscribe((response) => {
      this.transport.get('api/Posts/LikeCount', {postId: post.id}).subscribe((likeResponse) => {
        post.likeCount = <number>likeResponse
      })
    });
  }

  share(post: Post) {

  }

  order() {
    this.posts = this.posts.sort((first, second) => first.dateCreated < second.dateCreated ? (this.desc ? 1 : -1) : (this.desc ? -1 : 1));
    this.desc = !this.desc;
  }
}
