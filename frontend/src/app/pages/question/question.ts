import { Component, inject } from '@angular/core';
import { ExaminationService } from '../../services/examination.service';
import { Examination } from '../../models/examination';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-question',
  standalone: true, 
  imports: [FormsModule],
  templateUrl: './question.html',
  styleUrl: './question.scss',
})
export class QuestionPage {
  item : Examination = this.clear()
  

  private examinationService = inject(ExaminationService);
  private router = inject(Router);

  clear(){
    return {
        id: 0,
        question: "",
        answerChoiceNo: 0,
        answer1Detail: "",
        answer2Detail: "",
        answer3Detail: "",
        answer4Detail: "",
        recordTimestamp : new Date(),
    }
  }
  
  save(){  

    console.log('click save()');
    
    console.log(this.item.question);
    console.log(this.item.answer1Detail);
    console.log(this.item.answer2Detail);
    console.log(this.item.answer3Detail);
    console.log(this.item.answer4Detail);

    this.item.recordTimestamp = new Date();

    console.log(JSON.stringify(this.item, null, 2));    
    let e = this.examinationService.createExamination(this.item).subscribe({
      next: (response) => {
        console.log('บันทึกสำเร็จ!', response);
        // เพิ่มโค้ด เช่น โหลดตารางใหม่ หรือรีเซ็ตฟอร์มที่นี่
        this.clear();
        this.router.navigate(['/']);
      },
      error: (err) => {
        console.error('เกิดข้อผิดพลาด:', err);
      }
    });    
  }
  cancel(){
    this.item=this.clear();
    console.log('click cancel()');
  }
}
