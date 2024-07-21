import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-blog',
  standalone: true,
  imports: [],
  templateUrl: './blog.component.html',
  styleUrl: './blog.component.css'
})
export class BlogComponent {
  @Input() imageUrl: string = "";
  @Input() title: string = "";
  @Input() description: string = "";
  @Input() date: string = "";
  @Input() reads: number = 0;
  @Input() comments: number = 0;

}
