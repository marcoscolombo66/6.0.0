
import { Component, Injector, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { EquiposServiceProxy, EquipoDto, EquipoDtoPagedResultDto} from '@shared/service-proxies/service-proxies';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { PagedListingComponentBase, PagedRequestDto } from "shared/paged-listing-component-base";
import { EditarComponent } from "app/equipos/editar/editar.component";
import { CrearComponent } from "app/equipos/crear/crear.component";
import { finalize } from 'rxjs/operators';


@Component({
  selector: 'app-equipos',
  templateUrl: './equipos.component.html',
     
    animations: [appModuleAnimation()]
})
export class EquiposComponent extends PagedListingComponentBase<EquipoDto> {

    @ViewChild('createEquipoModal') createEquipoModal: CrearComponent;
    //@ViewChild('editTenantModal') editTenantModal: EditTenantComponent;

    equipos: EquipoDto[] = [];

    constructor(
        injector: Injector,
        public _equiposService: EquiposServiceProxy,
        private _modalService: BsModalService

  ) {
    super(injector);
}
    list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
        this._equiposService.getAll(undefined,request.skipCount, request.maxResultCount)
            .pipe(finalize(() => {
                finishedCallback();
            }))
            .subscribe((result: EquipoDtoPagedResultDto) => {
                this.equipos = result.items;
                this.showPaging(result, pageNumber);
            });
    }

    delete(equipos: EquipoDto): void {
        abp.message.confirm(
            this.l('EquipoDeleteWarningMessage', equipos.nombre_equipo),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._equiposService.delete(equipos.id)
                        .pipe(finalize(() => {
                            abp.notify.success(this.l('SuccessfullyDeleted'));
                            this.refresh();
                        }))
                        .subscribe(() => { });
                }
            }
        );
    }
    createEquipo(): void {
        this.showCreateOrEditEquipoDialog();
    }

    editEquipo(equipo: EquipoDto): void {
        this.showCreateOrEditEquipoDialog(equipo.id);
    }

    showCreateOrEditEquipoDialog(id?: number): void {
        let createOrEditEquipoDialog: BsModalRef;
        if (!id) {
            createOrEditEquipoDialog = this._modalService.show(
                CrearComponent,
                {
                    class: 'modal-lg',
                }
            );
        } else {
            createOrEditEquipoDialog = this._modalService.show(
                EditarComponent,
                {
                    class: 'modal-lg',
                    initialState: {
                        id: id,
                    },
                }
            );
        }

        createOrEditEquipoDialog.content.onSave.subscribe(() => {
            this.refresh();
        });
    }

}// FIN
