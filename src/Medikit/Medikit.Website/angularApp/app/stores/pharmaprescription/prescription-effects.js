var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, mergeMap } from 'rxjs/operators';
import { ActionTypes } from './prescription-actions';
import { PharmaPrescriptionService } from './services/prescription-service';
var PharmaPrescriptionEffects = (function () {
    function PharmaPrescriptionEffects(actions$, prescriptionService) {
        var _this = this;
        this.actions$ = actions$;
        this.prescriptionService = prescriptionService;
        this.getOpenedPrescriptions$ = this.actions$
            .pipe(ofType(ActionTypes.LOAD_PHARMA_PRESCRIPTIONS), mergeMap(function (evt) {
            return _this.prescriptionService.getOpenedPrescriptions(evt.patientNiss, evt.page, evt.samlAssertion)
                .pipe(map(function (prescriptionIds) { return { type: ActionTypes.PHARMA_PRESCRIPTIONS_LOADED, prescriptionIds: prescriptionIds }; }), catchError(function () { return of({ type: ActionTypes.ERROR_LOAD_PHARMA_PRESCRIPTIONS }); }));
        }));
        this.getPrescription$ = this.actions$
            .pipe(ofType(ActionTypes.LOAD_PHARMA_PRESCRIPTION), mergeMap(function (evt) {
            return _this.prescriptionService.getPrescription(evt.prescriptionId, evt.samlAssertion)
                .pipe(map(function (prescription) { return { type: ActionTypes.PHARMA_PRESCRIPTION_LOADED, prescription: prescription }; }), catchError(function () { return of({ type: ActionTypes.ERROR_LOAD_PHARMA_PRESCRIPTION }); }));
        }));
        this.addPrescription$ = this.actions$
            .pipe(ofType(ActionTypes.ADD_PHARMA_PRESCRIPTION), mergeMap(function (evt) {
            return _this.prescriptionService.addPrescription(evt.prescription, evt.samlAssertion)
                .pipe(map(function (prescriptionId) { return { type: ActionTypes.ADD_PHARMA_PRESCRIPTION_SUCCESS, prescriptionId: prescriptionId }; }), catchError(function () { return of({ type: ActionTypes.ADD_PHARMA_PRESCRIPTION_ERROR }); }));
        }));
        this.revokePrescription$ = this.actions$
            .pipe(ofType(ActionTypes.REVOKE_PHARMA_PRESCRIPTION), mergeMap(function (evt) {
            return _this.prescriptionService.revokePrescription(evt.rid, evt.reason, evt.samlAssertion)
                .pipe(map(function () { return { type: ActionTypes.REVOKE_PHARMA_PRESCRIPTION_SUCCESS, rid: evt.rid }; }), catchError(function () { return of({ type: ActionTypes.REVOKE_PHARMA_PRESCRIPTION_ERROR }); }));
        }));
    }
    __decorate([
        Effect(),
        __metadata("design:type", Object)
    ], PharmaPrescriptionEffects.prototype, "getOpenedPrescriptions$", void 0);
    __decorate([
        Effect(),
        __metadata("design:type", Object)
    ], PharmaPrescriptionEffects.prototype, "getPrescription$", void 0);
    __decorate([
        Effect(),
        __metadata("design:type", Object)
    ], PharmaPrescriptionEffects.prototype, "addPrescription$", void 0);
    __decorate([
        Effect(),
        __metadata("design:type", Object)
    ], PharmaPrescriptionEffects.prototype, "revokePrescription$", void 0);
    PharmaPrescriptionEffects = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [Actions,
            PharmaPrescriptionService])
    ], PharmaPrescriptionEffects);
    return PharmaPrescriptionEffects;
}());
export { PharmaPrescriptionEffects };
//# sourceMappingURL=prescription-effects.js.map