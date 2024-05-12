import { Component, Input } from '@angular/core';
import { MyCurs } from '../../../models/MyCurs';
import { typeCurs } from '../../../models/typeCurs';
@Component({
  selector: 'app-curs',
  templateUrl: './curs.component.html',
  styleUrl: './curs.component.scss'
})

export class CursComponent {
  @Input()
  curs:MyCurs={name:'',hours:0,type:typeCurs.frontal,date:""};
  @Input()
  i:number=0;
  alerrt(date:string){
    if(date>'05')
    {
      alert('הרישום בוצע בהצלחה');
    }
    else
    alert('הקורס נגמר')
  }
}
