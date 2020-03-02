import { Component, Injector } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { CreateModalComponent } from './create/create.modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto, PagedResultDto } from 'shared/paged-listing-component-base';
import { ToDoListServiceProxy, ToDoListDto, UserDtoPagedResultDto } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { MatDialog } from '@angular/material';
import { EditModalComponent } from './edit-modal/edit-modal.component';
import { AppSessionService } from '@shared/session/app-session.service';

@Component({
  selector: 'app-todo-list',
  animations: [appModuleAnimation()],
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent extends PagedListingComponentBase<ToDoListDto> {

  public bsModalRef: BsModalRef;
  public todoList: ToDoListDto[];

  constructor(
    injector: Injector,
    private modalService: BsModalService,
    private _toDoListService: ToDoListServiceProxy,
    private _dialog: MatDialog,
    private _appSessionService: AppSessionService) {
    super(injector);
  }


  onAddToDoClick() {
    this.modalService.config.animated = false;
    this.bsModalRef = this.modalService.show(CreateModalComponent, {
      backdrop: 'static',
      keyboard: false,
      class: 'tc-fullpage-modal-dialog'
    });
    this.bsModalRef.content.updateView();
    this.bsModalRef.content.dodoCreated = () => {
      //todo: refresh here.
    };
  }

  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {

    this._toDoListService
      .fetchAllToDos(this._appSessionService.userId)
      .pipe(
          finalize(() => {
              finishedCallback();
          })
      )
      .subscribe((result: ToDoListDto[]) => {
        this.todoList = result;
        const pgDto = new PagedResultDto();
        pgDto.items = result;
        pgDto.totalCount = result.length;
        this.showPaging(pgDto, pageNumber);
      });
  }
  protected delete(entity: ToDoListDto): void {
    abp.message.confirm(
      `Are you sure you want to delete ${entity.taskName}`,
      undefined,
      (result: boolean) => {
        if (result) {
          this._toDoListService.deleteToDo(entity).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  createToDo(): void {
    this.showCreateOrEditToDoListDialog();
  }

  editToDo(toDoItem: ToDoListDto): void {
    this.showCreateOrEditToDoListDialog(toDoItem);
  }

  private showCreateOrEditToDoListDialog(toDoItem?: ToDoListDto): void {
    let createOrEditToDoListDialog;
    if (toDoItem) {
      createOrEditToDoListDialog = this._dialog.open(EditModalComponent, {
        data: toDoItem
      });
    } else {
      createOrEditToDoListDialog = this._dialog.open(CreateModalComponent);
    }

    createOrEditToDoListDialog.afterClosed().subscribe(result => {
      if (result) {
        this.refresh();
      }
    });
  }


}
