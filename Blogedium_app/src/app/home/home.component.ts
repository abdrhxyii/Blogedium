import { Component } from '@angular/core';
import { BlogComponent } from '../blog/blog.component';
import { NavbarComponent } from '../navbar/navbar.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    BlogComponent,
    NavbarComponent
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  blogPosts = [
    {
      id: 1,
      imageUrl: '../../assets/dotnet.png',
      title: 'Blog Post 1',
      description: 'This is a description for Blog Post 1.',
      date: '2024-07-21',
      reads: 120,
      comments: 15
    },
    {
      id: 2,
      imageUrl: '../../assets/dotnet.png',
      title: 'Blog Post 2',
      description: 'This is a description for Blog Post 2.',
      date: '2024-07-22',
      reads: 200,
      comments: 25
    }
  ];

}
