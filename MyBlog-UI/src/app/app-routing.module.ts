import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContactsComponent } from './contacts/contacts.component';

import { PostListComponent } from './post-list/post-list.component';
import { PostComponent } from './post/post.component'

const routes: Routes = [
  { path: 'post-list', component: PostListComponent },
  { path: 'post', component: PostComponent },
  { path: 'contacts', component: ContactsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 
}
