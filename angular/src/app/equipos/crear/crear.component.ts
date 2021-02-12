import {
    Component,
    Injector,
    OnInit,
    Output,
    EventEmitter, ViewChild, ElementRef
} from '@angular/core'; 
import { AppComponentBase } from '@shared/app-component-base';
import { finalize } from 'rxjs/operators';

import * as _ from "lodash";
import {
    EquipoDto,
    EquiposServiceProxy
} from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AbpValidationError } from '@shared/components/validation/abp-validation.api';
@Component({
  selector: 'app-crear',
  templateUrl: './crear.component.html' 
   
})
export class CrearComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    equipo: EquipoDto = new EquipoDto();
    @Output() onSave = new EventEmitter<any>();
    constructor(
        injector: Injector,
        public _equipoService:EquiposServiceProxy,
        public bsModalRef: BsModalRef
    ) {
        super(injector);
    }

    ngOnInit(): void {
         
    }

    save(): void {
        this.saving = true;

        this._equipoService
            .create(this.equipo)
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
}
