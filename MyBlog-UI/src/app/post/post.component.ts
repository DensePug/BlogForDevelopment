import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {

  constructor(private route: ActivatedRoute) { }
  id: number | undefined;

  ngOnInit(): void {
    this.route.queryParamMap.subscribe(params => this.id = parseInt(<string>params.get('id')));
  }
}
