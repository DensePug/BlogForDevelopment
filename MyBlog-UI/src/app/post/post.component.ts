import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Post } from '../models/post';
import { TransportService } from '../transport.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {

  constructor(private route: ActivatedRoute, private transport: TransportService) { }
  post: Post | undefined;

  ngOnInit(): void {
    this.route.queryParamMap.subscribe(
      params => { 
          this.transport.get(`api/Posts/${parseInt(<string>params.get('id'))}`).subscribe((response) => {
            this.post = <Post>response;
          });
        });
  }
}
