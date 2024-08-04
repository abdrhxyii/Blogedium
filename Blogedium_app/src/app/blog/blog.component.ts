import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-blog',
  standalone: true,
  imports: [],
  templateUrl: './blog.component.html',
  styleUrl: './blog.component.css'
})
export class BlogComponent {
  constructor(private route: Router){

  }
  @Input() imageUrl: string = "";
  @Input() title: string = "";
  @Input() description: string = "";
  @Input() date: any = "";
  @Input() reads: number = 0;
  @Input() comments: number = 0;
  @Input() id: string = "";

  handleRoute(){
    this.route.navigate(["/blogpost"], { queryParams: {id: this.id}})
  }

}
