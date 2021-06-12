import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'MyBlog-UI';

  ngOnInit() {
    if (!localStorage.getItem('dateLoggedIn'))
      localStorage.setItem('dateLoggedIn', Date.now().toString());
  }
}
