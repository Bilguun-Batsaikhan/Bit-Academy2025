import { Component } from '@angular/core';

// component decorator
@Component({
  selector: 'app-profile',
  standalone: false,
  templateUrl: './profile.html',
  styleUrl: './profile.scss',
})
export class Profile {
  array: string[] = ['first', 'second', 'third']; // the default access modifier is public
  // array: Array<string> = ['first', 'second', 'third'];
  date: Date = new Date()

}
