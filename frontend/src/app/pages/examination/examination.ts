import { Component, OnInit, inject, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExaminationService } from '../../services/examination.service';
import { Examination } from '../../models/examination';
import { MatCardModule } from '@angular/material/card';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-examination',
  standalone: true,
  imports: [CommonModule,RouterModule],
  templateUrl: './examination.html',
  styleUrl: './examination.scss',
})
export class ExaminationPage implements OnInit {

  private examinationService = inject(ExaminationService);

  // 2. ฉีด (Inject) เข้ามาใน Constructor
  constructor(private cdr: ChangeDetectorRef) {}

  loading=false;

  questions: Examination[] = [];

  ngOnInit(): void {
    this.loading=false;
    console.debug('ngOnInit()');
    console.log('--- ngOnInit() ---');
    console.log('--- this.loading() ---' + this.loading);    
    this.examinationService.getQuestions().subscribe({
      next:(data) => {    
        this.questions = [...data];
        console.log(this.questions);
        this.loading = true;
        this.cdr.detectChanges();
        console.log('--- this.loading() ---' + this.loading);    
      },
      error: (err) => {
        console.error(err);
        this.loading = false;
      }
    })
  }

}