import { AfterViewInit, Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'pay-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.scss'],
})
export class RatingComponent implements AfterViewInit {
  @Input() control: FormControl;
  @Input() controlName: string;
  @Input() disabled: boolean;

  currentRate = 1;

  constructor() {}

  ngAfterViewInit(): void {
    this.control.valueChanges.subscribe((value) => {
      if (value && value !== this.currentRate) {
        this.currentRate = value;
      }
    });
  }

  updateInput($event: Event): void {
    if ($event.target instanceof HTMLInputElement) {
      const input = $event.target as HTMLInputElement;
      const numberedValue = Number.parseInt(input.value, 10);
      this.currentRate = numberedValue;
      this.control.setValue(numberedValue);
    }
  }
}
