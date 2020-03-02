import { Component, Injector, Optional, Inject, OnInit } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatCheckboxChange
} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import { ToDoListServiceProxy, ToDoListDto } from '@shared/service-proxies/service-proxies';
import { AppSessionService } from '@shared/session/app-session.service';

@Component({
  selector: 'app-edit-modal',
  templateUrl: './edit-modal.component.html',
  styleUrls: ['./edit-modal.component.css']
})
export class EditModalComponent extends AppComponentBase implements OnInit {
  saving = false;
  todo: ToDoListDto = new ToDoListDto();
  
  constructor(
    injector: Injector,
    public _todoListService: ToDoListServiceProxy,
    private _dialogRef: MatDialogRef<EditModalComponent>,
    private _appSessionService: AppSessionService,
    @Optional() @Inject(MAT_DIALOG_DATA) private _dto: ToDoListDto
  ) {
    super(injector);
    this.todo = _dto;
  }

  ngOnInit() {
  }

  save(): void {
    this.saving = true;
    this.todo.userId = this._appSessionService.userId;

    this._todoListService
      .insertOrUpdate(this.todo)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close(true);
      });
  }

  close(result: any): void {
    this._dialogRef.close(result);
  }

}
