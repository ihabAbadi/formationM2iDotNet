export class JobService {
    static dataContact = {
        firstName: '',
        lastName: '',
        birthDay: '',
        email: '',
        phoneNumber: '',
        linkedin: '',
        location: '',
        industryLike: ''
    }

    static data = []

    static reset = () => {
        this.dataContact = {
            firstName: '',
            lastName: '',
            birthDay: '',
            email: '',
            phoneNumber: '',
            linkedin: '',
            location: '',
            industryLike: ''
        }
    }
}