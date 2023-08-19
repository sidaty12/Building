import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment'
import { UserForLogin, UserForRegister } from '../model/user';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

     baseUrl = environment.baseUrl;
     
    constructor(private http : HttpClient) { }
// Initialisation avec la valeur actuelle dans le localStorage
private currentUserSubject = new BehaviorSubject<string>(localStorage.getItem('userName'));
public currentUser$ = this.currentUserSubject.asObservable();

    authUser(user: UserForLogin ) : Observable<any> {

      return this.http.post(this.baseUrl + '/account/login', user )
      .pipe(
        tap(response => {
          if(response && response.token) {
                        // Enregistrez le token d'accès et le userName dans le localStorage
                        localStorage.setItem('token', response.token);
                        localStorage.setItem('userName', response.userName);
                        
                         // Mise à jour du BehaviorSubject avec le nouveau nom d'utilisateur
                        this.currentUserSubject.next(response.userName);
                        // Supposons que le serveur renvoie également un refreshToken
                        if (response.refreshToken) {
                          localStorage.setItem('refreshToken', response.refreshToken);
          }
        }
        })
      )
}

isLoggedIn(): boolean {
  return !!localStorage.getItem('userName');
}
    registerUser(user: UserForRegister): Observable<any>{
      return this.http.post(this.baseUrl + '/account/register', user )

    }

    legout() : Observable<any> {
      const refreshToken = localStorage.getItem('refreshToken');
      if(!refreshToken) {
         // Si refreshToken n'existe pas, considérez la déconnexion comme réussie, 
      // mais nettoyez quand même le côté client.
      this.clearLocalStorage();
      return new Observable(observer => {
        observer.next(true);
        observer.complete();
      });
      }

       // Supposons que API ait une route `account/logout` pour gérer la déconnexion
    return this.http.post(this.baseUrl + '/account/logout', { refreshToken: refreshToken } )
    .pipe(
      tap(() => this.clearLocalStorage())
    );
    }

    private clearLocalStorage(): void {
      localStorage.removeItem('token');
      localStorage.removeItem('refreshToken');
      localStorage.removeItem('userName');
      this.currentUserSubject.next(null);

    }
    }






