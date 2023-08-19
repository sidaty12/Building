import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../services/alertify.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  loggedinUser: string;
  constructor(private alertify: AlertifyService, private authService: AuthService) { }

  ngOnInit() {
    this.authService.currentUser$.subscribe(username => {
      this.loggedinUser = username;
    })
  }

  loggedin() : string {
                               
    return localStorage.getItem('userName');
  }

  onLogout() {
    this.authService.legout().subscribe(
      () => {
        this.loggedinUser = null;
        this.alertify.success("You are logged out !");
      },
      error => {
        this.alertify.error("Error logging out.");
      }
    );
    }
}
