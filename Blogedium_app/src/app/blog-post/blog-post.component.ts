import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NavbarComponent } from '../navbar/navbar.component';

@Component({
  selector: 'app-blog-post',
  standalone: true,
  imports: [
    FormsModule,
    NavbarComponent
  ],
  templateUrl: './blog-post.component.html',
  styleUrl: './blog-post.component.css'
})
export class BlogPostComponent {
  blogdetails = {
    image: '../../assets/dotnet.png',
    createdAt: '2024-08-01T12:34:56Z',
    description: 'This is a hardcoded description of the blog post.',
  };

  comments = [
    {
      id: 1,
      first_name: 'John',
      last_name: 'Doe',
      createdAt: '2024-08-01T12:34:56Z',
      comment_des: 'This is a comment.'
    },
    {
      id: 2,
      first_name: 'Jane',
      last_name: 'Smith',
      createdAt: '2024-08-02T08:15:30Z',
      comment_des: 'Another insightful comment.'
    }
  ];

  input = {
    first_name: '',
    last_name: '',
    comment_des: ''
  };

  handleFieldTriggers(event: any) {
    const { name, value } = event.target;
    this.input = {
      ...this.input,
      [name]: value
    };
  }

  handleCommentSubmit() {
    // Handle comment submission logic
  }

  DateFormterring(date: string) {
    // Format date logic
    return new Date(date).toLocaleDateString();
  }
}
