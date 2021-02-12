import {
    Component,
    Injector,
    OnInit,
    Output,
    EventEmitter
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
    EquipoDto,
    EquiposServiceProxy
} from '@shared/service-proxies/service-proxies';
@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html'
   
})
export class EditarComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    equipo: EquipoDto = new EquipoDto();
    id: number;

    @Output() onSave = new EventEmitter<any>();

    constructor(
        injector: Injector,
        public _equipoService: EquiposServiceProxy,
        public bsModalRef: BsModalRef
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._equipoService.get(this.id).subscribe((result: EquipoDto) => {
            this.equipo = result;
            console.log('id',this.id)
        });
    }

    save(): void {
        this.saving = true;

        this._equipoService
            .update(this.equipo)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.bsModalRef.hide();
                this.onSave.emit();
            });
    }
}//FIN
