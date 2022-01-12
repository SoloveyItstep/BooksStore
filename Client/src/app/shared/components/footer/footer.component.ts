import { Component, OnInit } from '@angular/core';
import { LanguageService } from '../../../middleware/language.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent {

  constructor(public readonly langService: LanguageService) { }

  get Year(): number {
    return (new Date()).getFullYear();
  }

}
