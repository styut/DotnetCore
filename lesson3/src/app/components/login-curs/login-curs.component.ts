import { Component } from '@angular/core';
import { MyCurs } from '../../../models/MyCurs';
import { typeCurs } from '../../../models/typeCurs';

@Component({
  selector: 'app-login-curs',
  templateUrl: './login-curs.component.html',
  styleUrl: './login-curs.component.scss'
})
export class LoginCursComponent {
  curses: MyCurs[] = [
    {name:"english",hours:7,type:typeCurs.maabade,date:"06/08/2004"}, 
    {name:"java",hours:40,type:typeCurs.frontal,date:"04/02/2004"}, 
    {name:"python",hours:102,type:typeCurs.maabade,date:"02/010/2004"}, 
    {name:"qa",hours:9,type:typeCurs.frontal,date:"15/08/2004"}, 
  ]
}
