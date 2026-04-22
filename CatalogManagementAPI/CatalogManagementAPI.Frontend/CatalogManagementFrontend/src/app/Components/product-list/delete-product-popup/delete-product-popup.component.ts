
import { Component, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-delete-product-popup',
  templateUrl: './delete-product-popup.component.html',
  styleUrls: ['./delete-product-popup.component.scss']
})
export class DeleteProductPopupComponent {
  constructor(
    public dialogRef: MatDialogRef<DeleteProductPopupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ){}

  onConfirm(): void {
    this.dialogRef.close(true);
  }

  onCancel(): void{
    this.dialogRef.close(false)
  }
}