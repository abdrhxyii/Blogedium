import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-blog-card',
  standalone: true,
  imports: [],
  templateUrl: './blog-card.component.html',
  styleUrl: './blog-card.component.css'
})
export class BlogCardComponent {
  @Input() imageUrl: string;
  @Input title: string;
  @Input description: string;
  @Input date: string;
  @Input reads: string;
  @Input comments: number;
}
