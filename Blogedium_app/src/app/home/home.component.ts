import { Component } from '@angular/core';
import { BlogComponent } from '../blog/blog.component';
import { NavbarComponent } from '../navbar/navbar.component';
import { DataService } from '../data.service';

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
  blogPosts: any[] = [];
  constructor(private database: DataService){
    this.database.get("blog").subscribe((data: any)=> {
      this.blogPosts = data
      console.log(this.blogPosts)
    })
  }

  ngOnInit(){

  }

  truncateTitle(title: string): string {
    if (title.length > 40) {
      return title.substring(0, 40) + '...';
    }
    return title;
  }

  truncateContent(title: string): string {
    if (title.length > 70) {
      return title.substring(0, 70) + '...';
    }
    return title;
  }

  // blogPosts = [
  //   {
  //     id: 1,
  //     imageUrl: '../../assets/dotnet.png',
  //     title: 'Blog Post 1',
  //     description: 'This is a description for Blog Post 1.',
  //     date: '2024-07-21',
  //     reads: 120,
  //     comments: 15
  //   },
  //   {
  //     id: 2,
  //     imageUrl: '../../assets/dotnet.png',
  //     title: 'Blog Post 2',
  //     description: 'This is a description for Blog Post 2.',
  //     date: '2024-07-22',
  //     reads: 200,
  //     comments: 25
  //   }
  // ];

}
