import React from "react";
import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faMapMarker } from '@fortawesome/free-solid-svg-icons';
import { faPhone } from '@fortawesome/free-solid-svg-icons';
import { faEnvelope } from '@fortawesome/free-solid-svg-icons';
import { fab } from '@fortawesome/free-brands-svg-icons'
import './styles.css';

library.add(fab);

export default function Footer() {
  return (
    <div className="footer-distributed">
      <div className="footer-left">
        <h3>
          Company <span>Logo</span>
        </h3>
        <p className="footer-company-name">Company Name &copy; 2015</p>
      </div>

      <div className="footer-center">
          <div>
              <FontAwesomeIcon icon={faMapMarker}></FontAwesomeIcon>
              <p><span>89 South Circular Road</span>Dublin, Ireland</p>
          </div>

          <div>
              <FontAwesomeIcon icon={faPhone}></FontAwesomeIcon>
              <p>+353 83 361 0658</p>
          </div>

          <div>
              <FontAwesomeIcon icon={faEnvelope}></FontAwesomeIcon>
              <p><a href="mailto:support@company.com">support@company.com</a></p>
          </div>
      </div>

    <div className="footer-right">
        <p className="footer-company-about">
            <span>About the company</span>
            Lorem ipsum dolor sit amet, consectateur adispicing elit. Fusce euismod convallis velit, eu auctor lacus vehicula sit amet.
        </p>
    </div>

    <div class="footer-icons">
        <a href="#"><FontAwesomeIcon icon={['fab', 'facebook-f']}></FontAwesomeIcon></a>
        <a href="#"><FontAwesomeIcon icon={['fab', 'twitter']}></FontAwesomeIcon></a>
        <a href="#"><FontAwesomeIcon icon={['fab', 'linkedin']}></FontAwesomeIcon></a>
        <a href="#"><FontAwesomeIcon icon={['fab', 'github']}></FontAwesomeIcon></a>
    </div>

    </div>
  );
}
