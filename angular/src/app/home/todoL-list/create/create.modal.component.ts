import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { MatDialogRef } from '@angular/material';
import { ToDoListServiceProxy, ToDoListDto } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { AppSessionService } from '@shared/session/app-session.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.modal.component.html',
  styleUrls: ['./create.modal.component.css']
})
export class CreateModalComponent extends AppComponentBase implements OnInit {
  saving = false;
  todo: ToDoListDto = new ToDoListDto();

  constructor(
    injector: Injector,
    public _todoListService: ToDoListServiceProxy,
    private _dialogRef: MatDialogRef<CreateModalComponent>,
    private _appSessionService: AppSessionService) {
      super(injector);}

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
